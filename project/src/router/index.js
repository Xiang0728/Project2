import Vue from 'vue'
import VueRouter from 'vue-router'
import Home from '../views/Home.vue'
import MailList from '../views/MailList.vue'

Vue.use(VueRouter)

const routes = [
  {   
    path: '/',
    redirect: '/Home'   //重定向
  },
  {
    path: '/Home',
    name: 'Home',
    component: Home
  },
  {
    path: '/MailList',
    name: 'MailList',
    component:MailList
  
  }
]

const router = new VueRouter({
  mode: 'history',
  base: process.env.BASE_URL,
  routes
})

export default router
