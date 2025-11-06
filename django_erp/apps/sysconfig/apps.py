"""
Sysconfig app configuration.
"""

from django.apps import AppConfig


class SysconfigConfig(AppConfig):
    default_auto_field = 'django.db.models.BigAutoField'
    name = 'apps.sysconfig'
    verbose_name = 'System Configuration'

    def ready(self):
        """Import signals when app is ready."""
        # Import signals here if needed
        pass
