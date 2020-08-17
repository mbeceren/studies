import Vue from "vue";
import VueRouter from "vue-router";
import Home from "../views/Home.vue";
import store from "../store";

Vue.use(VueRouter);

const routes = [
  {
    path: "/",
    name: "Home",
    component: Home
  },
  {
    path: "/login",
    name: "Login",
    // route level code-splitting
    // this generates a separate chunk (about.[hash].js) for this route
    // which is lazy-loaded when the route is visited.
    component: () =>
      import(/* webpackChunkName: "about" */ "../views/Login.vue"),
  },
  {
    path: "/appointments",
    name: "Appointments",
    meta: {
      requeiresAuth:true
    },
    component: () =>
      import("../views/Appointments.vue")
  },
  {
    path: "/add-appointment",
    name: "AddAppointment",
    meta: {
      requeiresAuth:true
    },
    component: () =>
      import("../views/AddAppointment.vue")
  }
];

const router = new VueRouter({
  mode: "history",
  base: process.env.BASE_URL,
  routes
});

router.beforeEach((to, from, next) => {
  if (to.matched.some(record => record.meta.requeiresAuth)){
    if (store.getters.isLoggedIn){
      next();
      return;
    }
    next('login');
  } else {
    next();
  }
})

export default router;
