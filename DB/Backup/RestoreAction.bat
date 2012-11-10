echo "Restoring database..."
echo ""

sqlcmd -S .\SQLEXPRESS -i RestoreDB.sql -v database="WebFramework" -v root="%CD%"
