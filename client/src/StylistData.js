const _apiUrl = "/api/stylists";

export const getStylists = () => {
  return fetch("/api/stylists").then((response) => response.json())
}

export const changeStylistStatus = (id) => {
  return fetch(`${_apiUrl}/${id}`, {
    method: "DELETE"
  })
}

export const stylistStatus = (id) => {
  fetch(`${_apiUrl}/${id}`, {
    method: "PUT",
    headers: { "Content-Type": "application/json" }
  })
}

export const newStylist = (stylistObj) => {
  return fetch("/api/stylists", {
    method: "POST",
    headers: { "Content-Type": "application/json" },
    body: JSON.stringify(stylistObj),
  })
}