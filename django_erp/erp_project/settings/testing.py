"""
Testing settings for ERP Project.
"""

from .base import *  # noqa

# Use in-memory SQLite for faster tests
DATABASES = {
    'default': {
        'ENGINE': 'django.db.backends.sqlite3',
        'NAME': ':memory:',
    }
}

# Disable migrations for faster tests
class DisableMigrations:
    def __contains__(self, item):
        return True

    def __getitem__(self, item):
        return None

MIGRATION_MODULES = DisableMigrations()

# Speed up password hashing
PASSWORD_HASHERS = [
    'django.contrib.auth.hashers.MD5PasswordHasher',
]

# Disable logging during tests
LOGGING = {
    'version': 1,
    'disable_existing_loggers': True,
}

# Email to memory backend
EMAIL_BACKEND = 'django.core.mail.backends.locmem.EmailBackend'

# Disable cache
CACHES = {
    'default': {
        'BACKEND': 'django.core.cache.backends.dummy.DummyCache',
    }
}

# Media files in temp directory
MEDIA_ROOT = '/tmp/test_media/'

# Celery - run synchronously for tests
CELERY_TASK_ALWAYS_EAGER = True
CELERY_TASK_EAGER_PROPAGATES = True

# Debug must be False for certain tests
DEBUG = False

# Testing specific settings
TEST_RUNNER = 'django.test.runner.DiscoverRunner'
