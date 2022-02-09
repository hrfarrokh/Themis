cd..
dotnet ef migrations remove -f  `
    --context OrderDbContext `
    --project .\src\Themis.Infrastructure `
    --startup-project .\src\Themis.API `
    --verbose
