<template>
  <div class="modal" @keydown.esc="closeModal">
    <div class="popup-create d-flex flex-direction-column">
      <div class="popup-header d-flex justify-space-between align-center">
        <div class="popup-header-title">
          <slot name="title"></slot>
        </div>
        <div class="popup-header-icon icon icon-close cursor-pointer" @click="closeModal"></div>
      </div>
      <div class="popup-content flex1">
        <slot name="content"></slot>
      </div>
      <div class="popup-footer d-flex align-center">
        <slot name="footer"></slot>
      </div>
    </div>
  </div>
</template>

<script setup>
const emit = defineEmits(['closeModal'])
const closeModal = () => {
  emit('closeModal')
}
</script>

<style scoped>
/* Popup */
.modal {
  position: fixed;
  top: 0;
  left: 0;
  height: 100vh;
  width: 100vw;
  background-color: rgba(0, 0, 0, 0.5);
  z-index: 2;
}

/* Header popup */
.popup-create {
  width: 560px;
  height: calc(100% - 30px);
  background-color: #ffffff;
  border-radius: 5px;
  position: relative;
  top: 2%;
  margin: 0 auto;
  overflow: hidden;
  animation-name: popupAnimation;
  animation-duration: 0.5s;
}

/* Content popup */
.popup-content {
  overflow: auto;
  gap: 10px;
  padding: 24px;
}

.popup-header {
  height: 50px;
  padding: 24px 16px 0 24px;
}

.popup-header-title {
  font-size: 24px;
  font-weight: 700;
}

.popup-footer {
  height: 50px;
  padding: 9px 24px;
  justify-content: flex-end;
  gap: 5px;
  border-radius: 5px;
  background-color: #f1f2f5;
}

@keyframes popupAnimation {
  from {
    opacity: 0;
  }

  to {
    opacity: 1;
  }
}
</style>