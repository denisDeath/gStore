[Console]::OutputEncoding = [System.Text.Encoding]::GetEncoding("utf-8")

Set-Location -Path gs.api

echo "generate migrations..."
$migrationSuffix = Get-Date -Format "HHmmss"
&dotnet ef migrations add $migrationSuffix

echo "update database..."
&dotnet ef database update
echo "done"