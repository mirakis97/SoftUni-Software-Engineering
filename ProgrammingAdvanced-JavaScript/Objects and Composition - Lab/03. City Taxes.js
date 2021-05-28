function solve(n,m,k) {
    const city = {
        name: n,
        population: m,
        treasury: k,
        taxRate: 10,
        collectTaxes : function() {
            this.treasury += this.population * this.taxRate;
        },
        applyGrowth(percent){
           this.population += Math.floor(this.population * (percent / 100));
        },
        applyRecession(percent){
            this.treasury -= Math.floor(this.treasury * (percent / 100));
        },
    }

    return city;
}
