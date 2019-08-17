#ifndef HAD_CONFIG_H
#define HAD_CONFIG_H
#ifndef _HAD_ZIPCONF_H
#include "zipconf.h"
#endif
#ifdef _DEBUG
#include <sys/types.h> /* Sanity check for off_t */
#endif
/* BEGIN DEFINES */
/* #undef HAVE___PROGNAME */
#define HAVE__CHMOD
#define HAVE__CLOSE
#define HAVE__DUP
#define HAVE__FDOPEN
#define HAVE__FILENO
#define HAVE__OPEN
#define HAVE__SETMODE
#if defined(_MSC_VER) && _MSC_VER < 1900
#define HAVE__SNPRINTF
#else
/* #undef HAVE__SNPRINTF */
#endif
#define HAVE__STRDUP
#define HAVE__STRICMP
#define HAVE__STRTOI64
#define HAVE__STRTOUI64
#define HAVE__UMASK
#define HAVE__UNLINK
/* #undef HAVE_CLONEFILE */
/* #undef HAVE_COMMONCRYPTO */
#define HAVE_CRYPTO
/* #undef HAVE_FICLONERANGE */
#define HAVE_FILENO
/* #undef HAVE_FSEEKO */
/* #undef HAVE_FTELLO */
/* #undef HAVE_GETPROGNAME */
/* #undef HAVE_GNUTLS */
/* #undef HAVE_LIBBZ2 */
/* #undef HAVE_MBEDTLS */
/* #undef HAVE_MKSTEMP */
/* #undef HAVE_NULLABLE */
#define HAVE_OPEN
/* #undef HAVE_OPENSSL */
#define HAVE_SETMODE
/* #undef HAVE_SNPRINTF */
/* #undef HAVE_SSIZE_T_LIBZIP */
/* #undef HAVE_STRCASECMP */
#define HAVE_STRDUP
#define HAVE_STRICMP
#if !defined(_MSC_VER) || _MSC_VER >= 1800
#define HAVE_STRTOLL
#define HAVE_STRTOULL
#else
/* #undef HAVE_STRTOLL */
/* #undef HAVE_STRTOULL */
#endif
/* #undef HAVE_STRUCT_TM_TM_ZONE */
#if !defined(_MSC_VER) || _MSC_VER >= 1800
#define HAVE_STDBOOL_H
#else
/* #undef HAVE_STDBOOL_H */
#endif
/* #undef HAVE_STRINGS_H */
/* #undef HAVE_UNISTD_H */
#define HAVE_WINDOWS_CRYPTO
#define __INT8_LIBZIP 1
#define INT8_T_LIBZIP 1
#define UINT8_T_LIBZIP 1
#define __INT16_LIBZIP 2
#define INT16_T_LIBZIP 2
#define UINT16_T_LIBZIP 2
#define __INT32_LIBZIP 4
#define INT32_T_LIBZIP 4
#define UINT32_T_LIBZIP 4
#define __INT64_LIBZIP 8
#define INT64_T_LIBZIP 8
#define UINT64_T_LIBZIP 8
#define SHORT_LIBZIP 2
#define INT_LIBZIP 4
#define LONG_LIBZIP 4
#define LONG_LONG_LIBZIP 8
#ifdef _WIN64
#define SIZEOF_OFF_T 4 /* Still 32-bit for Win64 */
#define SIZE_T_LIBZIP 8
#else
#define SIZEOF_OFF_T 4
#define SIZE_T_LIBZIP 4
#endif
/* #undef SSIZE_T_LIBZIP */
/* #undef HAVE_DIRENT_H */
/* #undef HAVE_FTS_H */
/* #undef HAVE_NDIR_H */
/* #undef HAVE_SYS_DIR_H */
/* #undef HAVE_SYS_NDIR_H */
/* #undef WORDS_BIGENDIAN */
#define HAVE_SHARED
/* END DEFINES */
#define PACKAGE "libzip"
#define VERSION "1.5.2"

#ifndef HAVE_SSIZE_T_LIBZIP
#  if SIZE_T_LIBZIP == INT_LIBZIP
typedef int ssize_t;
#  elif SIZE_T_LIBZIP == LONG_LIBZIP
typedef long ssize_t;
#  elif SIZE_T_LIBZIP == LONG_LONG_LIBZIP
typedef long long ssize_t;
#  else
#error no suitable type for ssize_t found
#  endif
#endif

#ifdef _DEBUG
typedef char _sanity_check_SIZEOF_OFF_T[(sizeof(off_t) == SIZEOF_OFF_T) ? 1 : -1];
typedef char _sanity_check_SIZE_T_LIBZIP[(sizeof(size_t) == SIZE_T_LIBZIP) ? 1 : -1];
typedef char _sanity_check___INT8_LIBZIP[(sizeof(__int8) == __INT8_LIBZIP) ? 1 : -1];
typedef char _sanity_check_INT8_T_LIBZIP[(sizeof(int8_t) == INT8_T_LIBZIP) ? 1 : -1];
typedef char _sanity_check_UINT8_T_LIBZIP[(sizeof(uint8_t) == UINT8_T_LIBZIP) ? 1 : -1];
typedef char _sanity_check___INT16_LIBZIP[(sizeof(__int16) == __INT16_LIBZIP) ? 1 : -1];
typedef char _sanity_check_INT16_T_LIBZIP[(sizeof(int16_t) == INT16_T_LIBZIP) ? 1 : -1];
typedef char _sanity_check_UINT16_T_LIBZIP[(sizeof(uint16_t) == UINT16_T_LIBZIP) ? 1 : -1];
typedef char _sanity_check___INT32_LIBZIP[(sizeof(__int32) == __INT32_LIBZIP) ? 1 : -1];
typedef char _sanity_check_INT32_T_LIBZIP[(sizeof(int32_t) == INT32_T_LIBZIP) ? 1 : -1];
typedef char _sanity_check_UINT32_T_LIBZIP[(sizeof(uint32_t) == UINT32_T_LIBZIP) ? 1 : -1];
typedef char _sanity_check___INT64_LIBZIP[(sizeof(__int64) == __INT64_LIBZIP) ? 1 : -1];
typedef char _sanity_check_INT64_T_LIBZIP[(sizeof(int64_t) == INT64_T_LIBZIP) ? 1 : -1];
typedef char _sanity_check_UINT64_T_LIBZIP[(sizeof(uint64_t) == UINT64_T_LIBZIP) ? 1 : -1];
typedef char _sanity_check_SHORT_LIBZIP[(sizeof(short) == SHORT_LIBZIP) ? 1 : -1];
typedef char _sanity_check_INT_LIBZIP[(sizeof(int) == INT_LIBZIP) ? 1 : -1];
typedef char _sanity_check_LONG_LIBZIP[(sizeof(long) == LONG_LIBZIP) ? 1 : -1];
typedef char _sanity_check_LONG_LONG_LIBZIP[(sizeof(long long) == LONG_LONG_LIBZIP) ? 1 : -1];
#endif

#endif /* HAD_CONFIG_H */
