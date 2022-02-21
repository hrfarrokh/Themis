
set migration-anchor=%1
set migration-name=%2

cd..
dotnet ef database update %migration-anchor% --context MigrationsDbContext --verbose

dotnet ef migrations remove --context MigrationsDbContext --verbose

dotnet ef migrations add %migration-name% --context MigrationsDbContext --output-dir Infrastructure\EntityFramework\Migrations\Steps --verbose
