import { createWebHistory, createRouter } from 'vue-router';

const routes = [
  { path: '/error/404', component: () => import('@/pages/error/404') },
  {
    path: '/',
    component: () => import('@/layout'),
    children: [
      { path: '', redirect: 'home' },
      { name: 'Home', path: 'home', component: import('@/pages/Home') },
      { name: 'About', path: 'about', component: () => import('@/pages/About') },
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