# E-Commerce-Modul

Create a campaign with a name, a product code, duration, price manipulation limit and target sales count.  
- Campaign starts after creating and ends after given duration.  
- Duration is given in hours.  
- A price manipulation limit is the maximum percentage that you can increase or decrease the price of product according to demand.  
- Target sales count is the product quantity you want to sell during the campaign.  
- You will simulate time in your system. Time will start with 00:00 and it will be increased by you in any amount of hour.  


| Command | What it does |
| ------ | ------ |
| create_product PRODUCTCODE PRICE STOCK | Creates product in your system with given product information |
| get_product_info PRODUCTCODE | Prints product information for given product code |
| create_order PRODUCTCODE QUANTITY | Creates order in your system with given information |
| create_campaign NAME PRODUCTCODE DURATION PMLIMIT TARGETSALESCOUNT | Creates campaign in your system with given information |
| get_campaign_info NAME | Prints campaign information for given campaign name |
| increase_time HOUR | Increases time in your system |
   
      

| Steps Example | Output |
| ------ | ------ |
| create_product P1 100 1000 | Product created; code P1, price 100, stock 1000 |
| create_campaign C1 P1 5 20 100 | Campaign created; name C1, product P1, duration 5, limit 20 target sales count 100 |
| get_product_info P1 |Product P1 info; price 100, stock 1000 |
| increase_time 1 |Time is 01:00 |
| get_product_info P1 | Product P1 info; price 95, stock 1000 |
|increase_time 1 | Time is 02:00 |
|get_product_info P1 | Product P1 info; price 90, stock 1000 |
|increase_time 1 | Time is 03:00
|get_product_info P1 | Product P1 info; price 85, stock 1000|
|increase_time 1 |Time is 04:00 |
|get_product_info P1 |Product P1 info; price 80, stock 1000 |
|increase_time 2 | Time is 06:00 |
|get_product_info P1 |Product P1 info; price 100, stock 1000 |
| get_campaign_info C1 |Campaign C1 info; Status Ended, Target Sales 100, Total Sales 0, Turnover 0, Average Item Price – |
