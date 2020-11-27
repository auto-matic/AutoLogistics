# Database
## Structure
### Items
- Id
- Name
- Category_id
- Tags
- Place_id
- Description
- Owner_id
- Amount
- Unit
- Addition
- Possession

### Places
- Id
- Name
- Description
- Owner_id
- Addition
- Possession

### Owners
- Id
- Name
- Addition
- Possession

### Category
- Id
- Name
- Addition

``` sql
CREATE TABLE owners (
    owner_id INTEGER PRIMARY KEY,
    name TEXT NOT NULL,
    addition DATETIME2 NOT NULL,
    possesion DATETIME2 NOT NULL
);

CREATE TABLE places (
    place_id INTEGER PRIMARY KEY,
    name TEXT NOT NULL,
    description TEXT NOT NULL,
    FOREIGN KEY (owner_id) 
      REFERENCES owners (owner_id) 
         ON DELETE CASCADE 
         ON UPDATE NO ACTION,
    addition DATETIME2 NOT NULL,
    possesion DATETIME2 NOT NULL
)

CREATE TABLE items (
    item_id INTEGER PRIMARY KEY,
    name TEXT NOT NULL,
    FOREIGN KEY (category_id) 
      REFERENCES categories (category_id) 
         ON DELETE CASCADE 
         ON UPDATE NO ACTION,
    description TEXT NOT NULL,
    FOREIGN KEY (owner_id) 
      REFERENCES owners (owner_id) 
         ON DELETE CASCADE 
         ON UPDATE NO ACTION,
    amount INTEGER NOT NULL,
    unit Text,
    addition DATETIME2 NOT NULL,
    possesion DATETIME2 NOT NULL
)

CREATE TABLE categories (
    category_id INTEGER PRIMARY KEY,
    name TEXT NOT NULL,
    addition DATETIME2 NOT NULL
)
```