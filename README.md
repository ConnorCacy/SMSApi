# SMSApi
**Simple .Net Core API with Sql db repository accessed with dapper.**
*The actual SMS functionality is not included*
## Example Usage
*Recommend using Postman to test the api endpoints*

HTTP POST:
http://localhost:42089/api/SMS/SendMessageByAgtNumber?agtNumber=0000012345&msg=Hello_World
or simply:
http://localhost:42089/api/SMS/SendMessage?phoneNumber=2541231231&msg=Hello_World
