function solve(array) {
    const vehicles = array.reduce((acc,value) => {
        let [brand,model,produced] = value.split(' | ');
        produced = Number(produced);

        if (acc[brand]) {
            if (acc[brand][model]) {
                acc[brand][model] += produced;
            }
            else {
                acc[brand][model] = produced;
            }
        }
        else {
            acc[brand] = {
                [model] : produced
            };
        }
        return acc;
    }, {});

    Object.entries(vehicles).forEach((brand) => {
        const [brandType,ObjectData] = brand;
        console.log(`${brandType}\n${Object.entries(ObjectData).reduce((acc,value) => {
            const [model,quantity] = value;
            acc.push(`###${model} -> ${quantity}`);
            return acc;
        },[])
        .join('\n')}`
        );
    });
};