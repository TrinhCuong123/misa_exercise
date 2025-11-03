<template>
  <div class="toast" :class="stateToast == 'success' ? 'toast-success' : 'toast-info'">
    <div class="toast-header d-flex align-center">
      <div class="icon" :class="stateToast == 'success' ? 'icon-success' : 'icon-info'"></div>
      <!-- <div class="icon icon-info"></div> -->
      <div class="header-title" :class="stateToast == 'success' ? 'header-title-success' : 'header-title-info'">
        <slot name="header">{{ headerToast }}</slot>
      </div>
    </div>
    <div class="toast-content">
      <slot name="content"> {{ contentToast }} </slot>
    </div>
  </div>
</template>

<script setup>
defineProps({
  stateToast: {
    type: String,
    default: 'success', // success, info, warning, error
  },
  headerToast: {
    type: String,
    default: 'Thành công',
  },
  contentToast: {
    type: String,
    default: 'Đã thêm mới ứng viên thành công',
  },
})

</script>

<style scoped>
.toast {
  position: fixed;
  top: 20px;
  right: 20px;
  z-index: 9999;
  width: 300px;
  height: 60px;
  border-radius: 5px;
  padding: 8px;
  opacity: 0.9;
  animation-name: toastAnimation;
  animation-duration: 2s;
  /* thời gian chạy hiệu ứng */
  animation-timing-function: ease-in-out;
  /* mượt hơn */
  animation-fill-mode: forwards;
  /* giữ trạng thái cuối cùng */
}

.header-title {
  font-weight: 600;
  font-size: 16px;
  padding-left: 15px;
}

/* Toast success */
.toast-success {
  background-color: #f1fdf5;
}

.header-title-success {
  color: #16a34a;
}

.icon-success {
  background-color: #16a34a;
}

/* Toast info */
.toast-info {
  background-color: #f0f7ff;
}

.header-title-info {
  color: #2b67ec
}

.icon-info {
  background-color: #2b67ec;
}

@keyframes toastAnimation {
  0% {
    opacity: 0;
    transform: translateY(50px);
  }

  10% {
    opacity: 1;
    transform: translateY(0);
  }

  90% {
    opacity: 1;
    transform: translateY(0);
  }

  100% {
    opacity: 0;
    transform: translateY(50px);
  }
}
</style>