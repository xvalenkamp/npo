import { createRouter, createWebHistory, RouteRecordRaw } from "vue-router";
import HomeView from "../views/CameraView.vue";

const routes: Array<RouteRecordRaw> = [
  {
    path: "/",
    name: "cameras",
    component: HomeView,
  },
];

const router = createRouter({
  history: createWebHistory(process.env.BASE_URL),
  routes,
});

export default router;
