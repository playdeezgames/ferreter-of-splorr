Remove-Item -Path "./pub-html" -Recurse -Force
dotnet publish ./src/FerreterOfSplorr/FerreterOfSplorr.csproj -o ./pub-html -c Release 
Remove-Item -Path "./pub-html/*.pdb" -Force
butler push pub-html/wwwroot thegrumpygamedev/ferreter-of-splorr:html
