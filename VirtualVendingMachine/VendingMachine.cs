using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VirtualVendingMachine
{
    public class VendingMachine
    {
        public List <ProductSet> products = new List<ProductSet>(){
			    new ProductSet("Tea", 13, 10),
			    new ProductSet("Coffee", 18, 20),
			    new ProductSet("Milk Coffee", 21, 20),
			    new ProductSet("Juice", 35, 15)
	    };

        public List<CoinSet> coins = new List<CoinSet>(){
			    new CoinSet(1, 100),
			    new CoinSet(2, 100),
			    new CoinSet(5, 100),
			    new CoinSet(10, 100)
	    };
	
	    public Wallet wallet;
	    public Wallet tempwallet = new Wallet();
        
        public VendingMachine()
        {
            wallet = new Wallet(coins);
        }

        public List<ProductSet> getMenuList()
        {
		    return this.products;
        }   
    
        public ProductSet ProductSetByName(string name) {
		    foreach (ProductSet productSet in this.products) {
			    if (productSet.name == name)
				    return productSet;			
		    }
		    return null;
        }

        public bool Check(Product product)
        {
            return product.cost <= this.tempwallet.Sum();
        }

        public Wallet Buy(Product product)
        {
		    if (this.Check(product))
            {
			    ProductSet vmProduct = this.ProductSetByName(product.name);
			    if (vmProduct != null && vmProduct.count > 0) 
                {
				    --vmProduct.count;
                    this.wallet = this.wallet + this.tempwallet;
                    this.tempwallet = this.wallet.CoinsForChange(this.tempwallet.Sum() - product.cost);
                    this.wallet.Substruct(this.tempwallet);
			    }			
		    }
            return this.tempwallet;
        }    

        public Wallet Cancel() {
		    int coinsForCancel = this.tempwallet.Sum();
		    this.wallet = this.wallet + this.tempwallet;				
		    this.tempwallet.Clean();
            Wallet change = this.wallet.CoinsForChange(coinsForCancel);
            this.wallet.Substruct(change);
            return change;			
        }
    }
    
}
