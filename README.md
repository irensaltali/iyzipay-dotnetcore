﻿# iyzipay-dotnetcore

# Important Notice
This repo is derived from iyzipay-dotnet[https://github.com/iyzico/iyzipay-dotnet] under MIT license.

# Requirements

.NET Core 2.0

# Installation

You can fork this repo and build 'Iyzipay' project in release mode.
Then use that dll as reference.

You can sign up for an iyzico account at https://iyzico.com for API Keys.

# Contact
[irensaltali.com](https://irensaltali.com "İren SALTALI Blog")

# Follow Me On
[Twitter](https://twitter.com/irensaltali) - [LinkedIn](https://linkedin.com/in/irensaltali) - [Stack Overflow](https://stackoverflow.com/users/3453221/iren)

# Usage

```csharp
Options options = new Options();
options.ApiKey = "your api key";
options.SecretKey = "your secret key";
options.BaseUrl = "https://sandbox-api.iyzipay.com";
		
CreatePaymentRequest request = new CreatePaymentRequest();
request.Locale = Locale.TR.ToString();
request.ConversationId = "123456789";
request.Price = "1";
request.PaidPrice = "1.2";
request.Currency = Currency.TRY.ToString();
request.Installment = 1;
request.BasketId = "B67832";
request.PaymentChannel = PaymentChannel.WEB.ToString();
request.PaymentGroup = PaymentGroup.PRODUCT.ToString();

PaymentCard paymentCard = new PaymentCard();
paymentCard.CardHolderName = "John Doe";
paymentCard.CardNumber = "5528790000000008";
paymentCard.ExpireMonth = "12";
paymentCard.ExpireYear = "2030";
paymentCard.Cvc = "123";
paymentCard.RegisterCard = 0;
request.PaymentCard = paymentCard;

Buyer buyer = new Buyer();
buyer.Id = "BY789";
buyer.Name = "John";
buyer.Surname = "Doe";
buyer.GsmNumber = "+905350000000";
buyer.Email = "email@email.com";
buyer.IdentityNumber = "74300864791";
buyer.LastLoginDate = "2015-10-05 12:43:35";
buyer.RegistrationDate = "2013-04-21 15:12:09";
buyer.RegistrationAddress = "Nidakule Göztepe, Merdivenköy Mah. Bora Sok. No:1";
buyer.Ip = "85.34.78.112";
buyer.City = "Istanbul";
buyer.Country = "Turkey";
buyer.ZipCode = "34732";
request.Buyer = buyer;

Address shippingAddress = new Address();
shippingAddress.ContactName = "Jane Doe";
shippingAddress.City = "Istanbul";
shippingAddress.Country = "Turkey";
shippingAddress.Description = "Nidakule Göztepe, Merdivenköy Mah. Bora Sok. No:1";
shippingAddress.ZipCode = "34742";
request.ShippingAddress = shippingAddress;

Address billingAddress = new Address();
billingAddress.ContactName = "Jane Doe";
billingAddress.City = "Istanbul";
billingAddress.Country = "Turkey";
billingAddress.Description = "Nidakule Göztepe, Merdivenköy Mah. Bora Sok. No:1";
billingAddress.ZipCode = "34742";
request.BillingAddress = billingAddress;

List<BasketItem> basketItems = new List<BasketItem>();
BasketItem firstBasketItem = new BasketItem();
firstBasketItem.Id = "BI101";
firstBasketItem.Name = "Binocular";
firstBasketItem.Category1 = "Collectibles";
firstBasketItem.Category2 = "Accessories";
firstBasketItem.ItemType = BasketItemType.PHYSICAL.ToString();
firstBasketItem.Price = "0.3";
basketItems.Add(firstBasketItem);

BasketItem secondBasketItem = new BasketItem();
secondBasketItem.Id = "BI102";
secondBasketItem.Name = "Game code";
secondBasketItem.Category1 = "Game";
secondBasketItem.Category2 = "Online Game Items";
secondBasketItem.ItemType = BasketItemType.VIRTUAL.ToString();
secondBasketItem.Price = "0.5";
basketItems.Add(secondBasketItem);

BasketItem thirdBasketItem = new BasketItem();
thirdBasketItem.Id = "BI103";
thirdBasketItem.Name = "Usb";
thirdBasketItem.Category1 = "Electronics";
thirdBasketItem.Category2 = "Usb / Cable";
thirdBasketItem.ItemType = BasketItemType.PHYSICAL.ToString();
thirdBasketItem.Price = "0.2";
basketItems.Add(thirdBasketItem);
request.BasketItems = basketItems;

Payment payment = Payment.Create(request, options);
```
See other samples under Iyzipay.Samples project.

# Testing

You can run particular sample by passing your credential info to "Iyzipay.Samples/Sample.cs"

### Mock test cards

Test cards that can be used to simulate a *successful* payment:

Card Number      | Bank                       | Card Type
-----------      | ----                       | ---------
5890040000000016 | Akbank                     | Master Card (Debit)  
5526080000000006 | Akbank                     | Master Card (Credit)  
4766620000000001 | Denizbank                  | Visa (Debit)  
4603450000000000 | Denizbank                  | Visa (Credit)
4729150000000005 | Denizbank Bonus            | Visa (Credit)  
4987490000000002 | Finansbank                 | Visa (Debit)  
5311570000000005 | Finansbank                 | Master Card (Credit)  
9792020000000001 | Finansbank                 | Troy (Debit)  
9792030000000000 | Finansbank                 | Troy (Credit)  
5170410000000004 | Garanti Bankası            | Master Card (Debit)  
5400360000000003 | Garanti Bankası            | Master Card (Credit)  
374427000000003  | Garanti Bankası            | American Express  
4475050000000003 | Halkbank                   | Visa (Debit)  
5528790000000008 | Halkbank                   | Master Card (Credit)  
4059030000000009 | HSBC Bank                  | Visa (Debit)  
5504720000000003 | HSBC Bank                  | Master Card (Credit)  
5892830000000000 | Türkiye İş Bankası         | Master Card (Debit)  
4543590000000006 | Türkiye İş Bankası         | Visa (Credit)  
4910050000000006 | Vakıfbank                  | Visa (Debit)  
4157920000000002 | Vakıfbank                  | Visa (Credit)  
5168880000000002 | Yapı ve Kredi Bankası      | Master Card (Debit)  
5451030000000000 | Yapı ve Kredi Bankası      | Master Card (Credit)  

*Cross border* test cards:

Card Number      | Country
-----------      | -------
4054180000000007 | Non-Turkish (Debit)
5400010000000004 | Non-Turkish (Credit)  
6221060000000004 | Iran  

Test cards to get specific *error* codes:

Card Number       | Description
-----------       | -----------
5406670000000009  | Success but cannot be cancelled, refund or post auth
4111111111111129  | Not sufficient funds
4129111111111111  | Do not honour
4128111111111112  | Invalid transaction
4127111111111113  | Lost card
4126111111111114  | Stolen card
4125111111111115  | Expired card
4124111111111116  | Invalid cvc2
4123111111111117  | Not permitted to card holder
4122111111111118  | Not permitted to terminal
4121111111111119  | Fraud suspect
4120111111111110  | Pickup card
4130111111111118  | General error
4131111111111117  | Success but mdStatus is 0
4141111111111115  | Success but mdStatus is 4
4151111111111112  | 3dsecure initialize failed
