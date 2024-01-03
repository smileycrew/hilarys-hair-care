export const getCustomers = () => {
  return fetch("/api/customers").then((response) => response.json())
}

export const newCustomer = (customerObj) => {
    return fetch("/api/customers", {
      method: "POST",
      headers: { "Content-Type": "application/json" },
      body: JSON.stringify(customerObj),
    })
  }