param (
  [string]$project
)

$session = Get-Content -Path "./session.2017"
$domain = ".adventofcode.com"
$p = [int]$project


mkdir $project
cd $project
dotnet new console
dotnet new sln
dotnet sln add $project".csproj"
Copy-Item ../Program.cs .
New-Item test.txt
New-Item data.txt
$websession = New-Object Microsoft.PowerShell.Commands.WebRequestSession
$cookie = New-Object System.Net.Cookie
$cookie.Name = "session"
$cookie.Value = $session
$cookie.Domain = $domain
$websession.Cookies.Add($cookie)
$uri = "https://adventofcode.com/2017/day/$($p)/input" 
Invoke-WebRequest -Uri $uri -WebSession $websession -OutFile ./data.txt
Set-Location ..