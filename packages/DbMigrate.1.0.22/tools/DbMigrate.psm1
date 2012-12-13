$applicationRoot = get-location
$fluentMigratorExecutable = "$applicationRoot/packages/FluentMigrator.Tools.1.0.5.0/tools/AnyCPU/40/Migrate.exe"
$migrationsDirectory = "ColorSoft.Data.Migrations"
$configFile = "$applicationRoot/$migrationsDirectory/db-migrate.xml"
$migrationsDLL = "$applicationRoot/$migrationsDirectory/bin/Debug/ColorSoft.Data.Migrations.dll"

Function Db-Migrate([string]$environment="development", [string]$task="migrate", [string]$steps="1", [string]$version="0")
{
    Write-Host "Running database migration for $environment"
    [xml]$config = Get-Content $configFile

    $connectionString = ""

    foreach($env in $config.config.environment)
    {
        if($env.name -eq $environment)
        {
            $connectionString = $env.connectionString
            break
        }
    }

    Write-Host "Connection String: $connectionString"

    if($connectionString)
    {
        $args = @('/connection', $connectionString, '/db', 'sqlserver2008', '/target', $migrationsDLL, '/task', $task)

        if($task -eq "rollback")
        {
            $args += '/steps'
            $args += $steps
        }

        Write-Host "Calling exe with the following args: $args"
        & $fluentMigratorExecutable $args
    }
}

Export-Module Db-Migrate