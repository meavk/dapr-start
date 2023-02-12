namespace Transactions.Abstractions
{
    public class Address
    {
        public string? city { get; set; }
        public string? country { get; set; }
        public string? postal_code { get; set; }
        public string? state { get; set; }
        public string? state_code { get; set; }
        public string? house_number_or_name { get; set; }
        public string? line1 { get; set; }
        public string? line2 { get; set; }
        public string? organization { get; set; }
    }

    public class BillingDetails
    {
        public string? type { get; set; }
        public string? first_name { get; set; }
        public string? last_name { get; set; }
        public string? email_address { get; set; }
        public string? phone_number { get; set; }
        public Address? address { get; set; }
        public TaxId? tax_id { get; set; }
    }

    public class Buyer
    {
        public string? type { get; set; }
        public string? id { get; set; }
        public string? external_identifier { get; set; }
        public string? display_name { get; set; }
        public BillingDetails? billing_details { get; set; }
    }

    public class CartItem
    {
        public string? name { get; set; }
        public int quantity { get; set; }
        public int unit_amount { get; set; }
        public int discount_amount { get; set; }
        public int tax_amount { get; set; }
        public string? external_identifier { get; set; }
        public string? sku { get; set; }
        public string? product_url { get; set; }
        public string? image_url { get; set; }
        public List<string>? categories { get; set; }
        public string? product_type { get; set; }
    }

    public class Details
    {
        public string? card_type { get; set; }
        public string? bin { get; set; }
    }

    public class ErrorData
    {
        public string? description { get; set; }
        public string? detail { get; set; }
        public string? code { get; set; }
        public string? component { get; set; }
    }

    public class Metadata
    {
        public string? key { get; set; }
    }

    public class PaymentMethod
    {
        public string? type { get; set; }
        public string? id { get; set; }
        public string? method { get; set; }
        public string? external_identifier { get; set; }
        public string? label { get; set; }
        public string? scheme { get; set; }
        public string? expiration_date { get; set; }
        public string? approval_target { get; set; }
        public string? approval_url { get; set; }
        public string? currency { get; set; }
        public string? country { get; set; }
        public Details? details { get; set; }
    }

    public class PaymentService
    {
        public string? id { get; set; }
        public string? type { get; set; }
        public string? payment_service_definition_id { get; set; }
        public string? method { get; set; }
        public string? display_name { get; set; }
    }

    public class ResponseData
    {
        public string? cavv { get; set; }
        public string? eci { get; set; }
        public string? version { get; set; }
        public string? directory_response { get; set; }
        public string? authentication_response { get; set; }
        public string? cavv_algorithm { get; set; }
        public string? xid { get; set; }
    }

    public class Transaction
    {
        public string? type { get; set; }
        public string? id { get; set; }
        public string? status { get; set; }
        public string? intent { get; set; }
        public int amount { get; set; }
        public int captured_amount { get; set; }
        public int refunded_amount { get; set; }
        public string? currency { get; set; }
        public string? country { get; set; }
        public PaymentMethod? payment_method { get; set; }
        public Buyer? buyer { get; set; }
        public DateTime created_at { get; set; }
        public string? external_identifier { get; set; }
        public DateTime updated_at { get; set; }
        public PaymentService? payment_service { get; set; }
        public bool merchant_initiated { get; set; }
        public string? payment_source { get; set; }
        public bool is_subsequent_payment { get; set; }
        public StatementDescriptor? statement_descriptor { get; set; }
        public List<CartItem>? cart_items { get; set; }
        public string? scheme_transaction_id { get; set; }
        public string? raw_response_code { get; set; }
        public string? raw_response_description { get; set; }
        public string? avs_response_code { get; set; }
        public string? cvv_response_code { get; set; }
        public string? method { get; set; }
        public string? payment_service_transaction_id { get; set; }
        public Metadata? metadata { get; set; }
        public ShippingDetails? shipping_details { get; set; }
        public ThreeDSecure? three_d_secure { get; set; }
        public DateTime authorized_at { get; set; }
        public DateTime captured_at { get; set; }
        public DateTime voided_at { get; set; }
    }

    public class ShippingDetails
    {
        public string? type { get; set; }
        public string? id { get; set; }
        public string? buyer_id { get; set; }
        public string? first_name { get; set; }
        public string? last_name { get; set; }
        public string? email_address { get; set; }
        public string? phone_number { get; set; }
        public Address? address { get; set; }
    }

    public class StatementDescriptor
    {
        public string? name { get; set; }
        public string? description { get; set; }
        public string? city { get; set; }
        public string? phone_number { get; set; }
        public string? url { get; set; }
    }

    public class TaxId
    {
        public string? value { get; set; }
        public string? kind { get; set; }
    }

    public class ThreeDSecure
    {
        public string? version { get; set; }
        public string? status { get; set; }
        public string? method { get; set; }
        public ErrorData? error_data { get; set; }
        public ResponseData? response_data { get; set; }
    }

    public class Constants
    {
        public const string SampleTransactionJson = @"{
          ""type"": ""transaction"",
          ""id"": ""fe26475d-ec3e-4884-9553-f7356683f7f9"",
          ""status"": ""processing"",
          ""intent"": ""authorize"",
          ""amount"": 1299,
          ""captured_amount"": 999,
          ""refunded_amount"": 100,
          ""currency"": ""USD"",
          ""country"": ""US"",
          ""payment_method"": {
            ""type"": ""payment-method"",
            ""id"": ""77a76f7e-d2de-4bbc-ada9-d6a0015e6bd5"",
            ""method"": ""string"",
            ""external_identifier"": ""user-789123"",
            ""label"": ""1111"",
            ""scheme"": ""visa"",
            ""expiration_date"": ""11/25"",
            ""approval_target"": ""any"",
            ""approval_url"": ""https://api.example.app.gr4vy.com/payment-methods/ffc88ec9-e1ee-45ba-993d-b5902c3b2a8c/approve"",
            ""currency"": ""USD"",
            ""country"": ""US"",
            ""details"": {
              ""card_type"": ""credit"",
              ""bin"": ""412345""
            }
          },
          ""buyer"": {
            ""type"": ""buyer"",
            ""id"": ""fe26475d-ec3e-4884-9553-f7356683f7f9"",
            ""external_identifier"": ""user-789123"",
            ""display_name"": ""John L."",
            ""billing_details"": {
              ""type"": ""billing-details"",
              ""first_name"": ""John"",
              ""last_name"": ""Lunn"",
              ""email_address"": ""john@example.com"",
              ""phone_number"": ""+1234567890"",
              ""address"": {
                ""city"": ""London"",
                ""country"": ""GB"",
                ""postal_code"": ""789123"",
                ""state"": ""Greater London"",
                ""state_code"": ""GB-LND"",
                ""house_number_or_name"": ""10"",
                ""line1"": ""10 Oxford Street"",
                ""line2"": ""New Oxford Court"",
                ""organization"": ""Gr4vy""
              },
              ""tax_id"": {
                ""value"": ""12345678931"",
                ""kind"": ""gb.vat""
              }
            }
          },
          ""created_at"": ""2013-07-16T19:23:00.000+00:00"",
          ""external_identifier"": ""user-789123"",
          ""updated_at"": ""2019-08-24T14:15:22Z"",
          ""payment_service"": {
            ""id"": ""stripe-card-faaad066-30b4-4997-a438-242b0752d7e1"",
            ""type"": ""payment-service"",
            ""payment_service_definition_id"": ""stripe-card"",
            ""method"": ""string"",
            ""display_name"": ""Stripe (Main)""
          },
          ""merchant_initiated"": true,
          ""payment_source"": ""ecommerce"",
          ""is_subsequent_payment"": true,
          ""statement_descriptor"": {
            ""name"": ""GR4VY"",
            ""description"": ""Card payment"",
            ""city"": ""London"",
            ""phone_number"": ""+1234567890"",
            ""url"": ""www.gr4vy.com""
          },
          ""cart_items"": [
            {
              ""name"": ""GoPro HERO9 Camcorder"",
              ""quantity"": 1,
              ""unit_amount"": 37999,
              ""discount_amount"": 0,
              ""tax_amount"": 0,
              ""external_identifier"": ""item-789123"",
              ""sku"": ""sku-789123"",
              ""product_url"": ""https://example.com/items/gopro"",
              ""image_url"": ""https://example.com/images/items/gopro.png"",
              ""categories"": [
                ""string""
              ],
              ""product_type"": ""physical""
            }
          ],
          ""scheme_transaction_id"": ""123456789012345"",
          ""raw_response_code"": ""incorrect-zip"",
          ""raw_response_description"": ""The card's postal code is incorrect. Check the card's postal code or use a\ndifferent card."",
          ""avs_response_code"": ""partial_match_address"",
          ""cvv_response_code"": ""match"",
          ""method"": ""card"",
          ""payment_service_transaction_id"": ""charge_xYqd43gySMtori"",
          ""metadata"": {
            ""key"": ""value""
          },
          ""shipping_details"": {
            ""type"": ""shipping-details"",
            ""id"": ""8724fd24-5489-4a5d-90fd-0604df7d3b83"",
            ""buyer_id"": ""8724fd24-5489-4a5d-90fd-0604df7d3b83"",
            ""first_name"": ""John"",
            ""last_name"": ""Lunn"",
            ""email_address"": ""john@example.com"",
            ""phone_number"": ""+1234567890"",
            ""address"": {
              ""city"": ""London"",
              ""country"": ""GB"",
              ""postal_code"": ""789123"",
              ""state"": ""Greater London"",
              ""state_code"": ""GB-LND"",
              ""house_number_or_name"": ""10"",
              ""line1"": ""10 Oxford Street"",
              ""line2"": ""New Oxford Court"",
              ""organization"": ""Gr4vy""
            }
          },
          ""three_d_secure"": {
            ""version"": ""2.1.0"",
            ""status"": ""setup_error"",
            ""method"": ""challenge"",
            ""error_data"": {
              ""description"": ""Invalid ThreeDSCompInd"",
              ""detail"": ""The threeDSCompInd must be 'Y' when successful"",
              ""code"": ""305"",
              ""component"": ""C""
            },
            ""response_data"": {
              ""cavv"": ""3q2+78r+ur7erb7vyv66vv8="",
              ""eci"": ""05"",
              ""version"": ""string"",
              ""directory_response"": ""C"",
              ""authentication_response"": ""Y"",
              ""cavv_algorithm"": ""s"",
              ""xid"": ""string""
            }
          },
          ""authorized_at"": ""2013-07-16T19:23:00.000+00:00"",
          ""captured_at"": ""2013-07-16T19:23:00.000+00:00"",
          ""voided_at"": ""2013-07-16T19:23:00.000+00:00""
        }";
    }
}