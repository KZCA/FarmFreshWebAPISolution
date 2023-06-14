# FarmFreshWebAPISolution
Category
==========
GET
CategoryList
https://localhost:7047/api/Category
Add request description…
Authorization
Bearer Token
Token
<token>

GET
GetCategoryBySlug
https://localhost:7047/api/Category/fruits
Add request description…
Authorization
Bearer Token
Token
<token>

POST
AddNewCategory
https://localhost:7047/api/Category
Add request description…
Body
raw (json)
json
{  
  "name": "Fishes",
  "slug": "fish"
}
PUT
UpdateCategory
https://localhost:7047/api/Category
Add request description…
Body
raw (json)
json
{
  "id": 7,
  "name": "Fishes",
  "slug": "string"
}
DELETE
DeleteCategory
https://localhost:7047/api/Category/10

Product
==========
GET
ProductList
https://localhost:7047/api/Product
Add request description…
GET
ProductListByPagination
https://localhost:7047/api/Product/pagination/2/3
Add request description…
Authorization
Bearer Token
Token
<token>

GET
GetProductById
https://localhost:7047/api/Product/1
Add request description…
Authorization
Bearer Token
Token
<token>

Body
raw (json)
View More
json
{
    "productDetails": [
        {
            "id": 7,
            "name": "Banana",
            "slug": "banana",
            "description": "From the heart of the french Alps after a journey of more\r\nthan 70 years, springs this Ripe Blue Grapes. Thanks to\r\nthis amazing journey through the Chambotte mountains,\r\nit acquires its unique fresgqualities. With our passion for\r\npreserving this natural heritage, we are proud to offer you\r\nthis moment of purity in your busy lives.",
            "count": null,
            "categoryId": 1,
            "category": null,
            "image": "banana.jpg"
        },
        {
            "id": 6,
            "name": "Broccoli",
            "slug": "broccoli",
            "description": "From the heart of the french Alps after a journey of more\r\nthan 70 years, springs this Ripe Blue Grapes. Thanks to\r\nthis amazing journey through the Chambotte mountains,\r\nit acquires its unique fresgqualities. With our passion for\r\npreserving this natural heritage, we are proud to offer you\r\nthis moment of purity in your busy lives.",
            "count": null,
            "categoryId": 1,
            "category": null,
            "image": "broccoli.jpg"
        },
        {
            "id": 5,
            "name": "Tomato",
            "slug": "tomato",
            "description": "From the heart of the french Alps after a journey of more\r\nthan 70 years, springs this Ripe Blue Grapes. Thanks to\r\nthis amazing journey through the Chambotte mountains,\r\nit acquires its unique fresgqualities. With our passion for\r\npreserving this natural heritage, we are proud to offer you\r\nthis moment of purity in your busy lives.",
            "count": null,
            "categoryId": 1,
            "category": null,
            "image": "tomato.jpg"
        },
        {
            "id": 4,
            "name": "Capsicum",
            "slug": "capsicum",
            "description": "From the heart of the french Alps after a journey of more\r\nthan 70 years, springs this Ripe Blue Grapes. Thanks to\r\nthis amazing journey through the Chambotte mountains,\r\nit acquires its unique fresgqualities. With our passion for\r\npreserving this natural heritage, we are proud to offer you\r\nthis moment of purity in your busy lives.",
            "count": null,
            "categoryId": 1,
            "category": null,
            "image": "capsicum.jpg"
        },
        {
            "id": 2,
            "name": "Spinach",
            "slug": "spinach",
            "description": "From the heart of the french Alps after a journey of more\r\nthan 70 years, springs this Ripe Blue Grapes. Thanks to\r\nthis amazing journey through the Chambotte mountains,\r\nit acquires its unique fresgqualities. With our passion for\r\npreserving this natural heritage, we are proud to offer you\r\nthis moment of purity in your busy lives.",
            "count": null,
            "categoryId": 1,
            "category": null,
            "image": "spinach.jpg"
        }
    ],
    "pageIndex": 1,
    "totalData": 6,
    "totalPages": 2
}
GET
GetAllProductByIncludeCategory
https://localhost:7047/api/Product/GetAllProductByIncludeCategory?page=1&pagesize=2
Add request description…
Authorization
Bearer Token
Token
<token>

Query Params
page
1

pagesize
2

GET
GetProductByCategoryId
https://localhost:7047/api/Product/GetProductByCategoryId/9/1/1
Add request description…
Authorization
Bearer Token
Token
<token>

POST
AddNewProduct
https://localhost:7047/api/Product
Add request description…
Authorization
Bearer Token
Token
<token>

Body
raw (json)
View More
json
{
    "name": "MMM",
    "slug": "mm",
    "description": "From the heart of the french Alps after a journey of more\r\nthan 70 years, springs this Ripe Blue Grapes. Thanks to\r\nthis amazing journey through the Chambotte mountains,\r\nit acquires its unique fresgqualities. With our passion for\r\npreserving this natural heritage, we are proud to offer you\r\nthis moment of purity in your busy lives.",
    "count": null,
    "categoryId": 6,
    "category": {
        "name":"MMMCategory",
        "sub":"mm"
    },
    "image": "cow.jpg"
}
PUT
UpdateProduct
https://localhost:7047/api/Product
Add request description…
Body
raw (json)
View More
json
{
    "id":9,
    "name": "MMM",
    "slug": "mm",
    "description": "From the heart of the french Alps after a journey of more\r\nthan 70 years, springs this Ripe Blue Grapes. Thanks to\r\nthis amazing journey through the Chambotte mountains,\r\nit acquires its unique fresgqualities. With our passion for\r\npreserving this natural heritage, we are proud to offer you\r\nthis moment of purity in your busy lives.",
    "count": null,
    "categoryId": 6,
    "category": {
        "id":9,
        "name":"MMMCategory",
        "slug":"mm"
    },
    "image": "cow.jpg"
}
DELETE
DeleteProduct
https://localhost:7047/api/Product/9
Add request description…
JWTAuth
Add folder description…
GET
GetUser
https://localhost:7047/api/user
Add request description…
Authorization
Bearer Token
Token
<token>

POST
RequestToken
https://localhost:7047/api/authenticate
Add request description…
Body
raw (json)
json
{
  "name": "user1",
  "password": "password1"
}
GET
RefreshToken
https://localhost:7047/api/refresh
Add request description…
Body
raw (json)
View More
json
{
    "access_Token": "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJ1bmlxdWVfbmFtZSI6InVzZXIxIiwibmJmIjoxNjg2NTg3MzUxLCJleHAiOjE2ODY1ODc0MTEsImlhdCI6MTY4NjU4NzM1MX0.87pSIh5TeCiAgkm5Mg2ZQbffIgrMy9ehs2LVg3bvYiY",
    "refresh_Token": "Puy21rt3As/Fk6OJXPRdCftYlVzqrrOPxjRezNybiQ8="
}
Account
Add folder description…
POST
CreateUser
https://localhost:7047/api/Account/create
Add request description…
Body
raw (json)
json
{
    "id": "1",
    "name": "aa",
    "email": "aa@gmail.com",
    "password": "aaaa"
}
POST
Login
https://localhost:7047/api/Account/login
Add request description…
Authorization
Bearer Token
Token
<token>

Body
raw (json)
json
{ 
  "name": "BBB",
  "password": "123456"
}
