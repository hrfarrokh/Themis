[CmdletBinding()]
param (
    [Parameter()]
    [string]
    $MigrationName
)
cd..
dotnet ef migrations add $MigrationName `
    --context OrderDbContext `
    --project .\src\Themis.Infrastructure `
    --startup-project .\src\Themis.API `
    --output-dir .\Persistance\Migrations `
    --verbose
