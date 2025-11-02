# Domain Katmanı (Onion Architecture Çekirdeği)

Domain katmanı, uygulamanın kalbidir. Burada sistemin iş kuralları  ve temel kavramları tnaımlanır.

Bu katman hiç bir şekilde dış bir katmana bağlı olamaz!!!!
- Veritabanını bilmez!
- UI bilmez
- Ef Core, HTTP, Logger

Amaç: Uygulamanın değişmeyen iş kurallarını korumak.

## Domain Katmanı Ne Yapar?
Domain, sistemin ne olduğunu tanımlar, nasıl yaptığı ile ilgilenmez!

-Entities klasöründe sistemin temel varlıkları tutulur.
	- Category, Product, Supplier
	- Order, OrderDetail, Customer
	- JWT
	- Google Oauth
