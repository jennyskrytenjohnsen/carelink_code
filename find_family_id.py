import mysql.connector
import networkx as nx
import matplotlib.pyplot as plt

conn = mysql.connector.connect(
    host="localhost",
    user="root",
    password="",
    database="registrate_refugees"
)
cursor = conn.cursor()

print("Database connection is all good")

#Finds all relations defined in the family_relation table
cursor.execute('SELECT ALL asylum_card_ID1, asylum_card_ID2 FROM family_relation')
relationpairs = cursor.fetchall()


# Instanciate the networkx Graphs 
G = nx.Graph()
#  Defines the the relations
G.add_edges_from(relationpairs)

components  = list(nx.connected_components(G))

print(components)


#i will incremate for 1 for each component, the group is the all the refugee_id with relations. 
for i, group in enumerate(components, start=1):
    #In table refugee family --> Inserts family ID. (Creates a new family)
    cursor.execute("INSERT IGNORE INTO refugee_family (family_id) VALUES (%s)", (i,))
    
    #The new for loop goes through alle the refugees in every group and ads the correct family-ID
    for refugee_id in group:
        cursor.execute("INSERT IGNORE INTO refugee_family (family_id, asylum_card_ID) VALUES (%s, %s)",(i, refugee_id))

# Commits, saves and closes connection to database. 
conn.commit()
cursor.close()
conn.close()

print("Done :D")
