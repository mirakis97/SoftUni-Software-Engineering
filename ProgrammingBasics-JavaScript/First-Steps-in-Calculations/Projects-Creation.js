function projectsCreation(input) {
    let firstName = input.shift()
    let project = Number(input.shift())
    let hours = project * 3
    console.log(`The architect ${firstName} will need ${hours} hours to complete ${project} project/s. `)
}

projectsCreation(["George",4])
