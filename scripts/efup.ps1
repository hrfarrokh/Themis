[CmdletBinding()]
param (
    [Parameter()]
    [string]
    $MigrationName
)
cd..
dotnet ef database update $MigrationName `
    --context OrderDbContext `
    --project .\src\Themis.Infrastructure `
    --startup-project .\src\Themis.API `
    --verbose
