import { createWebHistory, createRouter } from 'vue-router';

const dynamicRoutes = require.context(
  '@/pages',
  true,
  /[^(index)]\.vue$/ // 탐색할 정규 표현식 (index를 제외한 js 파일들을 탐색합니다)
)

// const routeMap = {};
// ['./About.vue', './error/404.vue', './todo/TodoList.vue']


const routes = [
  {
    path: '/',
    component: () => import('@/layout'),
    redirect: '/home',
    children: [
      { name: 'Home', path: 'home', component: () => import('@/pages/Home') },
      // { name: 'About', path: 'about', component: () => import('@/pages/About') },
      // { 
      //   name: 'todo', 
      //   path: 'todo', 
      //   children: [
      //     { path: '/todo', redirect: 'list'},
      //     { name: 'todo-list', path: 'list', component: () => import('@/pages/todo/TodoList') },
      //   ]
      // }
    ],
  },  
  { path: '/error/404', component: () => import('@/pages/error/404') },
  { path: '/:pathMatch(.*)*', redirect:'/error/404' },
];

dynamicRoutes.keys().filter(item => !item.includes('/error')).forEach(filePath => {
  const moduleInfo = dynamicRoutes(filePath).default || dynamicRoutes(filePath);

  let fileName = filePath.replace('./', '');
  const routePathProperty = fileName.substring(0, fileName.indexOf('.vue'));
  const routeInfo = { 
    name: routePathProperty, 
    path: moduleInfo.alternativeUrl || routePathProperty, 
    component: moduleInfo 
  };
  routes[0].children.push(routeInfo)
});

const router = createRouter({
  history: createWebHistory(),
  linkActiveClass: "active",
  routes, 
});

export default router;