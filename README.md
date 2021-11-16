# libmanager_library-automation
#### Türkçe açıklaması için TURKISH.md ye bakınız
## Explanation
A library automation program. Made using C#. Database used is Microsoft Access. Comment lines are in Turkish.

## What it can do
- Has Layered Architecture.
- Can add or remove books or students.
- Can lend books and receive them back.
- Tracking who has received a book and who is currently keeping it.
- Delayed receivement and 2 day warnings. Delayed ones are in RED while 2 day warnings are in YELLOW
- Delivered books will be marked in green.
- Books ready to be returned will be marked in turquoise.
- Borrowing and returning operations will be stored historically.
- Books can be found with their code or name.
- 1 unit penalty will be given for each day of the book being delayed.
- All the books in the library, the books given to the students and the books which are ready to be given will be shown in graphic with Zedgrapgh.

## Requirements
- C#
- Zedgraph
- MS Access
- Visual Studio

## Layers
### Entity Layer
This is where we create the Access Tables with code and create the columns. In the code we created and encapsulated the variables that will come to these columns. We have made our classes public to provide access from other layers.
### Facade Layer
The layer in which SQL operations are performed. In this layer we work with the Entity Layer and we need to add or call the entity references.
### Business Logic Layer
This is where we check the values from the Presentation Layer and send them to the Facade Layer. Classes are public, entity and the Facade Layer are referenced and then called.
### Presentations Layer
It is the layer that the user sees. We send the values we take from Business Logic Layer. We need to refer and recall other layers here.
