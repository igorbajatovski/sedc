function amountToCoins(ammount, coins)
{    
    let ammountToCoins = [];
    for (const coin of coins) 
    {
        let containCoins = parseInt(ammount / coin);
        for(let i = 0; i < containCoins; ++i)
            ammountToCoins.push(coin);
        ammount -= coin * containCoins;
    }

    if(ammountToCoins.length === 0)
        return [0];
    return ammountToCoins;
}

console.log(`46 contains coins: ${amountToCoins(46, [25, 10, 5, 2, 1])}`);
console.log(`72 contains coins: ${amountToCoins(72, [25, 10, 5, 2, 1])}`);
console.log(`0 contains coins: ${amountToCoins(0, [25, 10, 5, 2, 1])}`);
console.log(`1 contains coins: ${amountToCoins(1, [25, 10, 5, 2, 1])}`);
console.log(`100 contains coins: ${amountToCoins(100, [25, 10, 5, 2, 1])}`);
console.log(`100 contains coins: ${amountToCoins(123, [25, 10, 5, 2, 1])}`);