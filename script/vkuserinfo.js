function ID() {
    var ID1 = document.getElementById('userID')
    setTimeout(gitID, 100)
}
function gitID() {
    import osmosis, { get, set } from 'osmosis';
    osmosis.get('https://vk.com/foaf.php?id=1')
    var FI = osmosis.set({ 'Title: ': 'title' })
    setTimeout(parsing, 1000)
}
function parsing() {
    document.getElementById('InfID').value = FI
}