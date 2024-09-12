# SVU-ITE-BPG401-F23
Home work in Syrian Virtual University with course BPG401 "Programming I"

You can read requiremints in file `./HM1-F23-BPG401.pdf`

## The program works with these steps
1. When starting the program, It will show the information system.
2. Get an input as an integer from the user, which is the number of questions.
3. Get inputs about the name, number (ID), and any other information. The accepted characters are `([A-Za-z]|[0-9]-(#|.|,|!|?))`. This project works with these steps: create a random number, then convert it to a character.

    The minimum length is 6 characters. Print it, then print it without spaces (as shown in the photo in the PDF homework) and without repetition, which means special characters.
4. Print the questions:
    1. Get input from the users between 20 and 80 to create a random string. Only characters accepted are `([A-Za-z]|[0-9]-(#|.|,|!|?))`.
    2. Get the input which is the count of special characters for two random strings.
    3. Get the input which is the count of similar characters from the first and second random strings.
    4. Store the results in four arrays:
        * The first: similar characters between each string and the special characters.
        * The second: characters accepted in the current string.
        * The third: the answers.
        * The fourth: the marks [0-3].
        * The user can skip an answer by writing "ignore," and the mark will be 0.
5. Show commands and execute them:
    1. Show random strings for all questions.
    2. Count all false answers.
    3. Count all true answers.
    4. Count all relatively correct answers.
    5. Mix the last commands.
    6. Exit command.
6. End program

## Mark home work
I got 100/100 with my friend with this project

## Build in Ubuntu
You need download some packges for run these command
```bash
mcs Program.cs
mono Program.exe
```