"""
View mixins for common functionality across the ERP system.
"""

from django.contrib.auth.mixins import LoginRequiredMixin, PermissionRequiredMixin
from django.contrib import messages
from django.shortcuts import redirect


class CompanyScopedMixin:
    """
    Mixin to automatically scope querysets to the user's company.
    """

    def get_queryset(self):
        """Filter queryset by user's company."""
        queryset = super().get_queryset()
        if hasattr(self.request.user, 'profile') and hasattr(self.request.user.profile, 'company'):
            return queryset.filter(company=self.request.user.profile.company)
        return queryset.none()

    def form_valid(self, form):
        """Automatically set company on create."""
        if hasattr(form.instance, 'company') and not form.instance.pk:
            if hasattr(self.request.user, 'profile'):
                form.instance.company = self.request.user.profile.company
        return super().form_valid(form)


class AuditMixin:
    """
    Mixin to automatically track created_by and updated_by.
    """

    def form_valid(self, form):
        """Set created_by and updated_by fields."""
        if not form.instance.pk:
            # New object - set created_by
            if hasattr(form.instance, 'created_by'):
                form.instance.created_by = self.request.user

        # Always update updated_by
        if hasattr(form.instance, 'updated_by'):
            form.instance.updated_by = self.request.user

        return super().form_valid(form)


class SuccessMessageMixin:
    """
    Add a success message on successful form submission.
    """
    success_message = ''

    def form_valid(self, form):
        response = super().form_valid(form)
        success_message = self.get_success_message(form.cleaned_data)
        if success_message:
            messages.success(self.request, success_message)
        return response

    def get_success_message(self, cleaned_data):
        return self.success_message % cleaned_data


class HTMXMixin:
    """
    Mixin for HTMX-specific view behavior.
    Uses partial templates for HTMX requests.
    """

    def get_template_names(self):
        """Return partial template for HTMX requests."""
        if self.request.htmx:
            # If it's an HTMX request, use the partial template
            if hasattr(self, 'htmx_template_name') and self.htmx_template_name:
                return [self.htmx_template_name]

            # Try to construct partial template name automatically
            template_names = super().get_template_names()
            htmx_templates = []
            for template_name in template_names:
                # Convert 'app/model_list.html' to 'app/partials/model_list.html'
                parts = template_name.split('/')
                if len(parts) > 1:
                    htmx_template = '/'.join(parts[:-1]) + '/partials/' + parts[-1]
                    htmx_templates.append(htmx_template)

            if htmx_templates:
                return htmx_templates + template_names

        return super().get_template_names()


class SoftDeleteMixin:
    """
    Mixin for soft delete functionality in views.
    """

    def delete(self, request, *args, **kwargs):
        """
        Soft delete instead of hard delete.
        """
        self.object = self.get_object()
        success_url = self.get_success_url()

        # Perform soft delete
        if hasattr(self.object, 'soft_delete'):
            self.object.soft_delete(user=request.user)
            messages.success(request, f'{self.object} has been deleted successfully.')
        else:
            # Fall back to hard delete if soft delete not available
            self.object.delete()
            messages.success(request, 'Record has been deleted successfully.')

        return redirect(success_url)


class RestrictedEditMixin:
    """
    Mixin to restrict editing based on approval status.
    """

    def get(self, request, *args, **kwargs):
        """Check if object can be edited."""
        self.object = self.get_object() if hasattr(self, 'get_object') else None

        if self.object and hasattr(self.object, 'is_editable'):
            if not self.object.is_editable():
                messages.error(
                    request,
                    'This record cannot be edited as it is in approval workflow.'
                )
                return redirect(self.object.get_absolute_url())

        return super().get(request, *args, **kwargs)


class ExportMixin:
    """
    Mixin to add export functionality to list views.
    """
    export_formats = ['csv', 'excel', 'pdf']

    def get_export_format(self):
        """Get export format from query parameter."""
        return self.request.GET.get('export', None)

    def is_export_request(self):
        """Check if this is an export request."""
        return self.get_export_format() in self.export_formats

    def export_to_csv(self, queryset):
        """Export queryset to CSV."""
        import csv
        from django.http import HttpResponse

        response = HttpResponse(content_type='text/csv')
        response['Content-Disposition'] = f'attachment; filename="{self.model.__name__}_export.csv"'

        writer = csv.writer(response)

        # Write header
        fields = [field.name for field in self.model._meta.fields]
        writer.writerow(fields)

        # Write data
        for obj in queryset:
            writer.writerow([getattr(obj, field) for field in fields])

        return response

    def export_to_excel(self, queryset):
        """Export queryset to Excel."""
        # Implementation using openpyxl or xlsxwriter
        pass

    def export_to_pdf(self, queryset):
        """Export queryset to PDF."""
        # Implementation using reportlab
        pass
