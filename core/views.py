from django.shortcuts import render, redirect
from django.contrib.auth import authenticate, login, logout
from django.contrib.auth.decorators import login_required
from django.http import HttpResponse


def login_view(request):
    """Login view for user authentication"""
    if request.method == 'POST':
        username = request.POST.get('username')
        password = request.POST.get('password')
        user = authenticate(request, username=username, password=password)

        if user is not None:
            login(request, user)
            # For HTMX, use HX-Redirect header
            response = HttpResponse(status=200)
            response['HX-Redirect'] = '/dashboard/'
            return response
        else:
            return HttpResponse(
                '<div class="bg-red-100 border border-red-400 text-red-700 px-4 py-3 rounded">'
                '<i class="fas fa-exclamation-circle mr-2"></i>Invalid username or password'
                '</div>'
            )

    return render(request, 'core/login.html')


@login_required
def dashboard_view(request):
    """Dashboard view - main page after login"""
    return render(request, 'core/dashboard.html')


def logout_view(request):
    """Logout view"""
    logout(request)
    return redirect('login')
