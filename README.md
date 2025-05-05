# carelink_code

For the database task:

registrate_refugees.sql contains the creation of all the tables in the database registrate_refugees.

The table refugee contains all information about the refugees.

The table refugee_relations contains all information about relations between the refugees. Each relation must be instantiated in this table using two asylum_card_IDs and a relation type, for example: asylum_card_ID1, asylum_card_ID2, 'Brother'.

The table place_of_residence stores the addresses where the refugees live.

The table refugee_family is updated automatically using the find_family_id.py script.

insert_instances.sql creates the data entries (instances) for the different database tables.


How to run find_family_id.py:

Install: pip install mysql-connector-python networkx
Run: find_family_id.py.
REMEMBER TO CHANGE YOU PASSWORD FOR THE DATABASE CONNECTION

Is can be run when new instances is created in table refugee_relations

