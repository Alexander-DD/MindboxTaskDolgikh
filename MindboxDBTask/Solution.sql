SELECT p.name AS productName,
       c.name AS categoryName
FROM product p
FULL JOIN product_category pc ON p.id = pc.productId
LEFT JOIN category c ON c.id = pc.categoryId;