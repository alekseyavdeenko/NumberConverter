# KMA.APZRPMJ2018.NumberConverter
Program that converts arabic numbers into roman numbers. Project #1 for NaUKMA APZRPMJ2018 class. 

Before converting you have to sign up (or sign in).

To convert:
1) Click 'New Conversion'.
2) In the 'Arabic Value' text box put value (from 0 to 5999).
3) Click 'Convert'.

Conversion is calculated in a new thread. Created users and conversions are deleted after the program shuts down. This program gives messages to the user if: Input values are invalid during sign up or sign in. Arabic value is invalid or exceeds allowed limits. Registration or conversion is impossible to complete.

Test results for task 1:
1) Registration process performs as expected with both valid and invalid data.
2) Convertion happens if allowed arabic value is given.
3) Program alerts the user that conversion is impossible to perform if arabic value is invalid.

Test results for task 2-3:
1) Logs out successfully.
2) Serializes all users and data.
3) Log in with existing user after the app was closed works just fine.

Test results for task 4:
1) Successfully autologins on start.
2) All data (exept for last user info) is saved in database.
3) Unsuccsessful and empty convertations are removed at the next log in.

User can go through all previous conversions and create new ones.

by Lisa Zhylina
