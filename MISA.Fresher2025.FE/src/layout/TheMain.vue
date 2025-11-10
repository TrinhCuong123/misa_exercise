<template>
  <div class="main-content flex1">
    <RouterView />
  </div>
</template>

<script setup>
import { RouterView } from 'vue-router';
</script>

<style scoped>
.main-content {
  background: #ebecef;
}
</style>