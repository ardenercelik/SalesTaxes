import axios from "axios";
import { BASE_URL } from "../const/constants";
const taxesApi = axios.create({
  headers: {
    "Content-Type": "application/json",
  },
  baseURL: BASE_URL,
});

export default {
  async getItem(id) {
    return await taxesApi({
      method: "get",
      url: "/taxableitems/" + id,
    });
  },
  getItems() {
    return taxesApi({
      method: "get",
      url: "/taxableitems/",
    });
  },
  updateItem(id, data) {
    return taxesApi({
      method: "put",
      url: "/taxableitems/" + id,
      data: data,
    });
  },
  postItem(data) {
    return taxesApi({
      method: "post",
      url: "/taxableitems/",
      data: data,
    });
  },
  deleteItem(id) {
    return taxesApi({
      method: "delete",
      url: "/taxableitems/" + id,
    });
  },
};
