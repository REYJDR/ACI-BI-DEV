SELECT 
Customers.CustomerID,
Customers.Customer_Bill_Name, 
JrnlHdr.Reference, 
JrnlHdr.CustVendId, 
LineItem.ItemID, 
LineItem.ItemDescription, 
JrnlHdr.TransactionDate, 
ABS(JrnlRow.Amount) as Amount, 
JrnlHdr.AmountPaid, JrnlHdr.MainAmount
FROM Customers Customers, JrnlHdr JrnlHdr, JrnlRow JrnlRow, LineItem LineItem
WHERE
LineItem.ItemRecordNumber = JrnlRow.ItemRecordNumber 
AND JrnlHdr.PostOrder = JrnlRow.PostOrder 
AND Customers.CustomerRecordNumber = JrnlRow.CustomerRecordNumber 
AND ((JrnlHdr.JrnlKey_Journal=3) 
AND (JrnlHdr.MainAmount>ABS(AmountPaid)) 
AND (JrnlRow.RowType=0))