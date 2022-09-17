# AbrilPersistence
Open JSON based persistance class that acts like a SQL database but is more simple to interact with.

Recommended for small projects and prototypes.

## Use
Just plop the class in your persistance layer and create an object
```Repository< yourClassHere > database = new Repository< yourClassHere >( yourFilePathHere.json );```
The creation of the object will automatically read the file and then you can use the Repository as a list containing all the objects, if you want to commit objects you added/modified to your list you can use
```database.Commit();```
and it will save to file.

## Repository public methods
`database.Commit();` Saves all changes to file.
`database.SelectAll();` Return an Array of all the objects in the repository.
`database.Where(< your predicate condition here >);` Returns an Array of all the objects in the repository that comply with the predicate.
