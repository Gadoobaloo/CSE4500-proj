//TODO: Retrieve info in JSON format from a public API. -- DONE

function getInfo(){
    fetch('https://www.boredapi.com/api/activity')
        .then(response => response.json())
        .then(json => {
            console.log('json object from API:')
            console.log(json)
            document.getElementById('activityText').innerHTML=json.activity;
        })
}