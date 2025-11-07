"""
Core application views.
"""

from django.shortcuts import render
from django.views.generic import TemplateView


class DashboardView(TemplateView):
    """
    Main dashboard view showing system overview.
    """
    template_name = 'dashboard.html'

    def get_context_data(self, **kwargs):
        context = super().get_context_data(**kwargs)
        # Add any dashboard-specific context here
        return context


def home_view(request):
    """
    Simple home view that redirects to dashboard.
    """
    return render(request, 'dashboard.html')
