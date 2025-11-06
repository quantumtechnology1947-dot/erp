# Django ERP System

Modern ERP system built with Django 5.1, HTMX, and Tailwind CSS.

## Tech Stack

- **Backend:** Django 5.1, Python 3.11
- **Frontend:** HTMX, Tailwind CSS (NO custom JavaScript/CSS)
- **Database:** PostgreSQL 15 (Development), SAP S/4 HANA (Production)
- **Cache/Queue:** Redis 7
- **Task Queue:** Celery
- **Testing:** pytest, pytest-django, coverage
- **Containerization:** Docker, Docker Compose

## Project Structure

```
django_erp/
├── apps/                   # Django applications
│   └── core/              # Core app with abstract models
├── erp_project/           # Main project settings
│   └── settings/          # Modular settings (base, dev, test, prod)
├── templates/             # Global templates
├── static/                # Static files (CSS, JS, images)
├── media/                 # User uploads
├── requirements/          # Python dependencies
├── tests/                 # Integration tests
├── logs/                  # Application logs
└── docker-compose.yml     # Docker services configuration
```

## Quick Start

### Prerequisites

- Docker & Docker Compose
- Python 3.11+ (for local development)
- Node.js 18+ (for Tailwind CSS)

### Using Docker (Recommended)

1. **Clone the repository**
   ```bash
   git clone <repo-url>
   cd django_erp
   ```

2. **Build and start services**
   ```bash
   docker-compose up --build
   ```

3. **Run migrations**
   ```bash
   docker-compose exec web python manage.py migrate
   ```

4. **Create superuser**
   ```bash
   docker-compose exec web python manage.py createsuperuser
   ```

5. **Access the application**
   - Web: http://localhost:8000
   - Admin: http://localhost:8000/admin

### Local Development (Without Docker)

1. **Create virtual environment**
   ```bash
   python3 -m venv venv
   source venv/bin/activate  # On Windows: venv\Scripts\activate
   ```

2. **Install dependencies**
   ```bash
   pip install -r requirements/development.txt
   ```

3. **Set up environment variables**
   ```bash
   cp .env.example .env
   # Edit .env with your configuration
   ```

4. **Run migrations**
   ```bash
   python manage.py migrate
   ```

5. **Create superuser**
   ```bash
   python manage.py createsuperuser
   ```

6. **Run development server**
   ```bash
   python manage.py runserver
   ```

## Testing

### Run all tests
```bash
pytest
```

### Run with coverage
```bash
pytest --cov=apps --cov-report=html
```

### Run specific test file
```bash
pytest apps/core/tests/test_models.py
```

### Run tests in parallel
```bash
pytest -n auto
```

## Docker Commands

### Start services
```bash
docker-compose up
```

### Start in background
```bash
docker-compose up -d
```

### Stop services
```bash
docker-compose down
```

### View logs
```bash
docker-compose logs -f web
```

### Run Django commands
```bash
docker-compose exec web python manage.py <command>
```

### Access Django shell
```bash
docker-compose exec web python manage.py shell_plus
```

### Run tests in Docker
```bash
docker-compose exec web pytest
```

## Core Features

### Abstract Models (All apps inherit from these)

- **TimeStampedModel** - Auto-managed created_at/updated_at
- **SoftDeleteModel** - Logical deletion
- **CompanyScopedModel** - Multi-company support
- **AuditMixin** - created_by/updated_by tracking
- **ApprovalWorkflowModel** - Check → Approve → Authorize workflow

### View Mixins

- **CompanyScopedMixin** - Auto-filter by company
- **AuditMixin** - Auto-set audit fields
- **HTMXMixin** - Partial template support
- **SoftDeleteMixin** - Soft delete in views
- **RestrictedEditMixin** - Prevent editing approved records

### Utilities

- Code generation (unique & sequential)
- Currency formatting
- GST calculation
- Financial year management
- GSTIN/PAN validation
- Number to words conversion

### Custom Validators

- Phone number (Indian format)
- GSTIN (15 characters)
- PAN (10 characters)
- Pincode (6 digits)
- IFSC code (bank)
- Positive numbers
- Percentage (0-100)
- File upload validation

## Development Guidelines

### Django Conventions

1. **Use Class-Based Views** - ListView, CreateView, UpdateView, DeleteView
2. **Use Django ORM** - Avoid raw SQL
3. **Use Built-in Admin** - Don't create custom admin from scratch
4. **Follow Django naming** - apps, models, views, templates

### HTMX First

1. **No custom JavaScript** unless absolutely necessary
2. **Use HTMX attributes** for dynamic behavior
3. **Server-side rendering** for SEO
4. **Progressive enhancement**

### Tailwind CSS Only

1. **No custom CSS files**
2. **Use Tailwind utility classes** only
3. **Responsive by default**
4. **Consistent design system**

### Testing Requirements

1. **80% code coverage minimum**
2. **Write tests BEFORE implementation** (TDD)
3. **Test all workflows** end-to-end
4. **Use factories** for test data (factory-boy)

## Environment Variables

Create a `.env` file (copy from `.env.example`):

```env
SECRET_KEY=your-secret-key-here
DEBUG=True
ALLOWED_HOSTS=localhost,127.0.0.1

DATABASE_URL=postgresql://user:password@localhost:5432/erp_db
REDIS_URL=redis://localhost:6379/1

CELERY_BROKER_URL=redis://localhost:6379/0
CELERY_RESULT_BACKEND=redis://localhost:6379/0
```

## Database Migrations

### Create migrations
```bash
python manage.py makemigrations
```

### Apply migrations
```bash
python manage.py migrate
```

### Show migrations
```bash
python manage.py showmigrations
```

### Rollback migration
```bash
python manage.py migrate <app_name> <migration_name>
```

## Celery Tasks

### Start Celery worker
```bash
celery -A erp_project worker -l info
```

### Start Celery beat (scheduler)
```bash
celery -A erp_project beat -l info
```

### Monitor Celery with Flower
```bash
celery -A erp_project flower
```

## Static Files

### Collect static files
```bash
python manage.py collectstatic --noinput
```

### Compile Tailwind CSS
```bash
npm run build:css
```

### Watch for changes (development)
```bash
npm run watch:css
```

## Code Quality

### Format code with Black
```bash
black apps/
```

### Check with flake8
```bash
flake8 apps/
```

### Sort imports with isort
```bash
isort apps/
```

### Run all quality checks
```bash
black apps/ && isort apps/ && flake8 apps/
```

## Deployment

### Production checklist

- [ ] Set DEBUG=False
- [ ] Set strong SECRET_KEY
- [ ] Configure ALLOWED_HOSTS
- [ ] Set up PostgreSQL/SAP HANA
- [ ] Configure Redis
- [ ] Set up email backend
- [ ] Configure static files (WhiteNoise)
- [ ] Set up Sentry for error tracking
- [ ] Configure SSL certificates
- [ ] Set up backups
- [ ] Configure monitoring

### Build for production
```bash
docker-compose -f docker-compose.prod.yml up --build
```

## Contributing

1. Follow Django coding conventions
2. Write tests for all new features
3. Maintain 80%+ code coverage
4. Use Black for code formatting
5. Update documentation
6. Create pull requests with clear descriptions

## License

Proprietary - All rights reserved

## Support

For issues and questions:
- Create an issue in the repository
- Contact the development team

## Roadmap

### Phase 0: Foundation (Current)
- [x] Django project setup
- [x] Core abstract models
- [x] Testing framework
- [ ] Docker environment
- [ ] Tailwind CSS + HTMX
- [ ] Base templates
- [ ] CI/CD pipeline

### Phase 1: Core System (Next)
- [ ] SysConfig app (Company, Financial Year, Locations)
- [ ] Accounts app (Authentication, Users, Permissions)

### Future Phases
- HR, Sales, Procurement, Inventory modules
- Full approval workflows
- Reporting and analytics
- SAP S/4 HANA integration

---

**Version:** 0.1.0 (Phase 0)
**Last Updated:** 2025-11-06
