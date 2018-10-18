#wait for the SQL Server to come up
sleep 90s

echo '..:: DOING DB SETUP ::..'
#run the setup script to create the DB and the schema in the DB
# /opt/mssql-tools/bin/sqlcmd -j -S localhost -U sa -P 1aArdV4rk7 -d master -i setup.sql