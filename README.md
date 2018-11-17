# NumberConverter
Program that converts arabic numbers into roman numbers. Project #1 for NaUKMA APZRPMJ2018 class. 

Before converting you have to sign up (or sign in).
To convert:
Click 'New Conversion'.
In the 'Arabic Value' text box put value (from 0 to 5999).
Click 'Convert'.

Conversion is calculated in a new thread. Created users and conversions are deleted after the program shuts down.
This program gives messages to the user if:
Input values are invalid during sign up or sign in.
Arabic value is invalid or exceeds allowed limits.
Registration or conversion is impossible to complete.

Test results:
Registration process performs as expected with both valid and invalid data.
Convertion happens if allowed arabic value is given.
Program alerts the user that conversion is impossible to perform if arabic value is invalid.

Test results 2:
Logs out successfully.
Serializes all users and data.
Log in with existing user after the app was closed works just fine.

User can go through all previous conversions and create new ones.

by Aleksey Avdeenko, Lisa Zhylina
