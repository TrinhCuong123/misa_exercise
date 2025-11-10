<template>
  <div class="sidebar-container h-100-percent">
    <!-- Sidebar item list -->
    <div class="sidebar-menu d-flex flex-column justify-space-between">
      <div>
        <div class="menu-item" v-for="item in items" :key="item.url">
          <RouterLink class="menu-link" :to="item.url">
            <div class="menu-content">
              <div class="icon icon-style" :class="item.icon"></div>
              <div class="menu-title">{{ item.name }}</div>
            </div>
          </RouterLink>
        </div>
      </div>
      <div class="back-button">
        <div class="content-back d-flex align-center">
          <div class="icon icon-left"> </div>
          <div class="title-button">Thu gọn</div>
        </div>
      </div>
    </div>
  </div>
</template>

<script setup>
import { ref } from "vue"

// Sidebar navigation items
const items = ref([
  { name: "Trang chủ", url: "/", icon: "icon-recruitment-news" },
  { name: "Khách hàng", url: "/customer", icon: "icon-candidate" },
  { name: "Đơn hàng", url: "/sale-order", icon: "icon-potential-pool" }
])
</script>

<style scoped>
/* Main sidebar container */
.sidebar-container {
  min-width: 233px;
  background: #030f1d;
}

/* Wrapper for all sidebar items */
.sidebar-menu {
  padding: 32px 0 16px;
  height: 100%;
}

/* Remove default link style */
.menu-link {
  text-decoration: none !important;
}

/* Layout for each sidebar item */
.menu-content {
  display: flex;
  align-items: center;
  padding: 8px 12px;
  margin: 0 12px 12px;
  color: #c5ccd5;
  font-weight: 500;
}

.menu-content:hover {
  background-color: rgba(255, 255, 255, 0.1);
  border-radius: 4px;
}

/* Text label next to the icon */
.menu-title {
  margin-left: 12px;
  font-size: 14px;
}

/* Default icon styling */
.icon-style {
  background-color: #c5ccd5;
}

.title-button {
  color: #fff;
  font-weight: 500;
  margin-left: 12px;
}

/* Active link (current route) */
.router-link-exact-active .menu-content {
  background-color: #2680EB;
  color: #fff;
  border-radius: 4px;
}

.router-link-exact-active .icon-style {
  background-color: #fff;
}

/* Footer sidebar */
.back-button {
  padding: 0px 12px;
}
.content-back {
  padding: 8px;
  background-color: rgba(255, 255, 255, 0.1);
  height: 40px;
  border-radius: 4px;
  cursor: pointer;
}
.icon-left {
  background-color: #fff;
}
</style>