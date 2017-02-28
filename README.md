Specs:

* The get all method will return an empty list if the list of students is empty in the beginning
    * input: nothing/null
    * output: empty string

* The equals method will return true if there are two students that are the same
    * input: Sally, Sally
    * output: true

* The get all method will return the student if the student was saved in the database
    * input: Sally
    * output: Sally

* The save method will assign a new id to a new instance of the student class
    * Input: Sally, 0
    * Output: Sally, non zero

* The get all method will return a list of all students
    * input: Sally, Henry, Bob
    * output: Sally, Henry, Bob

* The find method will return the student in the database.
    * input: Sally
    * output: Sally

* When the user updates the name of a student, the update method will return the updated name
    * input: Bob replacing Sally
    * output: Bob

* When the user deletes a student, the delete method will return an updated list without the deleted student
    * input: DELETE Bob
    * output: Henry

* The get all method will return an empty list if the list of classes is empty in the beginning
    * input: nothing/null
    * output: empty string

* The equals method will return true if there are two classes that are the same
    * input: Music, Music
    * output: true

* The save and get all methods will return true if the class was saved in the database
    * input: Music
    * output: true

* The get all method will return true if the id for the first restaurant has an id of 1.
    input: Music
    output: 1

* The get all method will return a list of all classes
    * input: Music, Math, English
    * output: Music, Math, English
