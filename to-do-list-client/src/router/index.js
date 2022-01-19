import { createWebHistory, createRouter } from 'vue-router';


const dynamicRoutes = require.context(
  '@/pages',
  true,
  /[^(index)]\.vue$/ // 탐색할 정규 표현식 (index를 제외한 js 파일들을 탐색합니다)
)

console.log(dynamicRoutes);

const routes = [
  { path: '/error/404', component: () => import('@/pages/error/404') },
  {
    path: '/',
    component: () => import('@/layout'),
    children: [
      { path: '', redirect: 'home' },
      { name: 'Home', path: 'home', component: import('@/pages/Home') },
      { name: 'About', path: 'about', component: () => import('@/pages/About') },
      { 
        name: 'todo', 
        path: 'todo', 
        children: [
          { path: '/todo', redirect: 'list'},
          { name: 'todo-list', path: 'list', component: () => import('@/pages/todo/TodoList') },
        ]
      }
    ],
  },  
  { path: '/:pathMatch(.*)*', redirect:'/error/404' },
];

const router = createRouter({
  history: createWebHistory(),
  linkActiveClass: "active",
  routes, 
});

export default router;