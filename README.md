# carelink_code

## Database Task

### registrate_refugees.sql
- Contains the creation of all tables in the registrate_refugees database.

- The refugee table contains all information about the refugees.

- The refugee_relations table contains all information about relations between the refugees. 
  Each relation must be instantiated in this table using two asylum_card_IDs and a relation type, for example:
  asylum_card_ID1, asylum_card_ID2, 'Brother'.

- The place_of_residence table stores the addresses where the refugees live.

- The refugee_family table is updated automatically using the find_family_id.py script.

### insert_instances.sql
Creates the data entries (instances) for the different database tables.

### How to run find_family_id.py:

1. Install:
pip install mysql-connector-python networkx

2. Run:
find_family_id.py

- Remember to change your password for the database connection

- find_family.py can be run when new instances are created in the refugee_relations table.

## API task: 

### Download: 
dotnet add package Microsoft.EntityFrameworkCore
dotnet add package Pomelo.EntityFrameworkCore.MySql
dotnet add package Microsoft.EntityFrameworkCore.Tools
dotnet add package Swashbuckle.AspNetCore
dotnet add package Microsoft.AspNetCore.OpenApi

### How to run
1. Remember to insert the password to your local database in appsettings.json and turn on the MySQL connection on your computer.

2. Open the .cs files.

3. In the Terminal, go to the carelink_api folder.

4. Write: dotnet run in the terminal

5. Insert http://localhost:5077/swagger/index.html as a web address (note: your computer might use another localhost address – be observant).

6. Try the APIs :D
