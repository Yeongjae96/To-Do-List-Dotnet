import { request, requestAndGetData } from "@/utils/Http";
export async function getTodoList(data) {
  return requestAndGetData({
    url: "/todo",
    method: "get",
    data,
  });
}
export async function getTodo(no) {
  return requestAndGetData({
    url: "/todo/{no}",
    method: "get",
    data: {
      no,
      pathVariable: true,
    },
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
  return request({
    url: "/todo",
    method: "put",
    data,
  });
}

export async function deleteTodo(data) {
  return request({
    url: "/todo/{no}",
    method: "delete",
    data,
  });
}

export async function updateCompleted(data) {
  return request({
    url: "/todo/completed",
    method: "put",
    data,
  });
}
