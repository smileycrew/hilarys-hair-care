export const getServices = () => {
    return fetch("/api/services").then((response) => response.json())
}