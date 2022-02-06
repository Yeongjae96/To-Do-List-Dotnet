import { request, requestAndGetData } from "@/utils/Http";
export async function getTodoList(data) {
  return requestAndGetData({
    url: "/todo",
    method: "get",
    data,
  });
}
export async function insertTodo(data) {
  return request({
    url: "/api/todo",
    method: "post",
    data,
  });
}
export async function updateTodo(data) {
  return requestAndGetData({
    url: "/todo",
    method: "put",
    data,
  });
}

export async function deleteTodo(data) {
  return requestAndGetData({
    url: "/todo/{id}",
    method: "delete",
    data,
  });
}
